using System;
using DddVariants.Variant1;
using DddVariants.Variant1.Infrastructure;

namespace DddVariants.Variant1Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dispatcher = new Dispatcher(new Bus());

            var creationResult = dispatcher.DispatchCreation(new CreateApplicant
            {
                Name = "First name at creation"
            });

            Console.WriteLine(creationResult);

            creationResult = dispatcher.DispatchCreation(new CreateApplicant
            {
                Name = "Second name at creation"
            });

            Console.WriteLine(creationResult);

            dispatcher.Dispatch(new RenameApplicant
            {
                Id = ((CreationOk) creationResult).Id,
                Name = "New name"
            });
        }
    }
}
