using Autofac;
using CQRS.Core;
using CQRS.DTO;
using CQRS.Core.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Core;

namespace CQRS
{
    class Program
    {
        public static IContainer AppContainer { get; set; }
        static void Main(string[] args)
        {
            AppContainer = CreateContainer();

            Console.WriteLine("Test Simple Command Segrigation");
            TestDeleteUser(5);

            Console.WriteLine("Test Query Segrigation");
            var userDetails = TestGetUserDetails(10);
            Console.WriteLine($"User Fist Name:{userDetails.FirstName}");

            Console.WriteLine("Test List Query Segrigation");
            var userList = TestGetAllActiveUser();
            foreach(var user in userList)
            {
                Console.WriteLine($"Name : {user.FirstName} {user.LastName}");
            }

            //TestFuncRegistration();

            Console.ReadKey();
        }

        private static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DeleteUserCommand>().As<ICommand>();
            builder.RegisterType<DeleteUserHandler>().As<ICommandHandler<DeleteUserCommand>>();
            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();
            builder.RegisterType<UserAccountService>().As<IUserAccountService>();

            builder.RegisterType<UserDetailsQuery>().As<IQuery<UserDetails>>();
            builder.RegisterType<UserDetailsQueryHandler>().As<IQueryHandler<UserDetailsQuery, UserDetails>>();
            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>();

            builder.RegisterType<UserListQuery>().As<IQuery<IEnumerable<UserDetails>>>();
            builder.RegisterType<UserListQueryHandler>().As<IQueryHandler<UserListQuery, IEnumerable<UserDetails>>>();

            builder.Register((c, p) => new ConfigReader(p.Named<string>("configName"), p.Named<bool>("isFiltered")))
                    .As<IConfigReader>();

            var container = builder.Build();

            return container;
        } 

        private static void TestDeleteUser(int userId)
        {
            var command = new DeleteUserCommand();
            command.UserId = userId;

            var commandDeciper = AppContainer.Resolve<ICommandDispatcher>();
            commandDeciper.Execute<DeleteUserCommand>(command);
        }

        private static UserDetails TestGetUserDetails(int userId)
        {
            var query = new UserDetailsQuery();
            query.Id = userId;

            var queryDispatcher = AppContainer.Resolve<IQueryHandler<UserDetailsQuery, UserDetails>>();

            return queryDispatcher.Execute(query);
        }

        private static IEnumerable<UserDetails> TestGetAllActiveUser()
        {
            var query = new UserListQuery();

            query.IsActive = true;

            var queryDispatcher = AppContainer.Resolve<IQueryHandler<UserListQuery, IEnumerable<UserDetails>>>();

            return queryDispatcher.Execute(query);
        }
        private static void TestFuncRegistration()
        {
            using(var scope = AppContainer.BeginLifetimeScope())
            {
                var parameters = new List<Parameter>()
                {
                    {new NamedParameter("configName", "root") },
                    {new NamedParameter("isFiltered",true)}
                };

                var configReader = scope.Resolve<IConfigReader>(parameters);
                configReader.Process();
            }
        }
    }
}
