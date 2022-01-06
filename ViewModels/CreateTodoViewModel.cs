using Flunt.Notifications;
using Flunt.Validations;

namespace MiniTodo.ViewModels
{
    public class CreateTodoViewModel : Notifiable<Notification>
    {
        public string Title { get; set; }
        public string Description { get; set; }


        public Todo MapTo() {
            var contract = new Contract<Notification>()
                .Requires()
                .IsNotNull(Title, "Informe o título da tarefa")
                .IsGreaterThan(Title, 5, "O título deve conter pelo menos 5 caracters");

            AddNotifications(contract);

            return new Todo(Guid.NewGuid(), Title, false);        
        }
    }
}
