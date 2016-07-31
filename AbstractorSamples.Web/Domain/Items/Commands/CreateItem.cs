using System.ComponentModel.DataAnnotations;
using Abstractor.Cqrs.Infrastructure.Operations;
using Abstractor.Cqrs.Interfaces.Operations;

namespace AbstractorSamples.Web.Domain.Items.Commands
{
    [Log]
    // Informs the framework that the command should be logged by the concrete implementation of ILogger interface.
    [Transactional] 
    // Informs the framework that the command should be atomic, executed inside a transaction.
    public class CreateItem : ICommand
    {
        [Required]
        // The framework uses the default DataAnnotations for command validation, so you can use all validation attributes provided by this package.
        public string Name { get; set; }
        // By definition commands should be immutable, but in this example the command is received as a parameter in the controller, so we need to provide the set acessor for model binding.
    }
}