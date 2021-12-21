namespace FirstProgram
{
  /// <summary>
  /// main class.
  /// </summary>
  internal class Program
  {
    /// <summary>
    /// main method.
    /// </summary>
    /// <param name="args">Main.</param>
    public static void Main(string[] args)
    {
      string reply;
      bool input = true;
      while (input == true)
      {
        Console.WriteLine("would you like to view the database?");
        reply = Console.ReadLine();

        if (reply == "yes")
        {
          var database = Crud.ReadAll();
          foreach (var item in database)
          {
            Console.WriteLine(item.ToString());
          }
        }
        else if (reply == "no")
        {
          Console.WriteLine("would you like to add a record?");
          reply = Console.ReadLine();
          if (reply == "yes")
          { 
            AddPerson person = new AddPerson();
            Console.WriteLine("please enter the name of the person");
            person.Name = Console.ReadLine();
            Console.WriteLine("please enter the phone number of the person");
            person.Phone = Console.ReadLine();
            Console.WriteLine("please enter the email of the person");
            person.Email = Console.ReadLine();
            Crud.Create(person);
          }
          else if (reply == "no")
          {
            Console.WriteLine("would you like to update a record?");
            reply = Console.ReadLine();
            if (reply == "yes")
            {
              Person updatePerson = new Person();
              Console.WriteLine("what is the Id of the person you would like to update?");
              updatePerson.Id = Convert.ToInt32(Console.ReadLine());
              Console.WriteLine("please enter the name of the person");
              updatePerson.Name = Console.ReadLine();
              Console.WriteLine("please enter the phone number of the person");
              updatePerson.Phone = Console.ReadLine();
              Console.WriteLine("please enter the email of the person");
              updatePerson.Email = Console.ReadLine();
              Crud.Update(updatePerson);
            }
            else if (reply == "no")
            {
              Console.WriteLine("would you like to delete a record?");
              reply = Console.ReadLine();

              if (reply == "yes")
              {
                Person deletePerson = new Person();
                Console.WriteLine("what is the Id of the person you would like to delete?");
                int id = Convert.ToInt32(Console.ReadLine());
                Crud.Delete(id);
              }
              else if (reply == "no")
              {
                Console.WriteLine("thank you for using my database program");
                input = false;
              }
            }
          }
        }
      }
      }
   }
}