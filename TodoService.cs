namespace Oop;

public abstract class TodoService
{
    public abstract void Add(Todo todo);
    public abstract Todo? Remove(int id);
    public abstract Todo? Update(int id, bool completed);
    public abstract List<Todo> GetAll();
}

public class LocalTodoService : TodoService
{
    private List<Todo> todos = new List<Todo>();

    public override void Add(Todo todo)
    {
        todos.Add(todo);
    }

    public override List<Todo> GetAll()
    {
        return todos;
    }

    public override Todo? Remove(int id)
    {
        Todo? todo = todos.Find(all => all.Id == id);
        if (todo == null)
        {
            return null;
        }

        todos.Remove(todo);
        return todo;
    }

    public override Todo? Update(int id, bool completed)
    {
        Todo? todo = todos.Find(all => all.Id == id);
        if (todo == null)
        {
            Console.WriteLine($"A todo-item with id {id} was not found.");
            return null;
        }

        todo.Completed = completed;
        return todo;
    }
}

// public class DatabaseTodoService : TodoService { }
