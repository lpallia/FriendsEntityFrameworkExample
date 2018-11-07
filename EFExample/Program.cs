using DataAccess;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Agenda a = new Agenda()
            {
                Name = "Agenda 1",
                Contacts = new List<User>()
            };

            Agenda b = new Agenda()
            {
                Name = "Agenda 2",
                Contacts = new List<User>()
            };

            User owner = new User()
            {
                Age = 24,
                Name = "Ramiro"
            };

            User owner2 = new User()
            {
                Age = 34,
                Name = "Leonardo"
            };

            User contact1 = new User()
            {
                Age = 22,
                Name = "Lady"
            };

            User contact2 = new User()
            {
                Age = 21,
                Name = "Sir"
            };

            User contact3 = new User()
            {
                Age = 21,
                Name = "TercerContacto"
            };

            a.Contacts.Add(contact1);
            a.Contacts.Add(contact2);
            a.Owner.Add(owner);
            a.Owner.Add(owner2);

            b.Contacts.Add(contact3);
            b.Owner.Add(owner);
            b.Owner.Add(contact1);

            Console.WriteLine("Se va a agegar la agenda 1");
            Console.ReadKey();

            IDataAccess<Agenda> dataAccess = new AgendaDataAccess();
            dataAccess.Add(a);

            Console.WriteLine("Agenda 1 Agregada");
            Console.ReadKey();
            Console.WriteLine("Se va a obtener la agenda 1 \n\n");
            Console.ReadKey();
            Agenda aCopy = dataAccess.Get(a.Id);

            Console.WriteLine(aCopy.Id);
            Console.WriteLine(aCopy.Name);

            Console.WriteLine("Contacts: \n");

            foreach (var u in aCopy.Contacts)
            {
                Console.WriteLine(u.Name);
            }

            Console.WriteLine("\n");

            Console.WriteLine("Owners de la agenda 1: \n");
            foreach (var u in aCopy.Owner)
            {
                Console.WriteLine(u.Name);
            }

            Console.WriteLine("\n");

            Console.WriteLine("Se va a agregar la agenda 2");
            dataAccess.Add(b);

            Console.WriteLine("Agenda 2 Agregada");
            Console.ReadKey();
            Console.WriteLine("Se va a obtener la agenda 2 \n\n");
            Console.ReadKey();
            Agenda bCopy = dataAccess.Get(b.Id);
            
            Console.WriteLine(bCopy.Id);
            Console.WriteLine(bCopy.Name);


            Console.WriteLine("Contacts: \n");

            foreach (var u in bCopy.Contacts)
            {
                Console.WriteLine(u.Name);
            }

            Console.WriteLine("\n");

            Console.WriteLine("Owners de la agenda 2: \n");
            foreach (var u in bCopy.Owner)
            {
                Console.WriteLine(u.Name);
            }

            Console.WriteLine("\n");

            /////

            Console.WriteLine("\n\nSe va a modificar la agenda 1");
            Console.ReadKey();

            aCopy = dataAccess.Get(a.Id);
            aCopy.Name = "BLABLA";
            aCopy.Contacts.Add(new User() { Name = "Kid", Age = 20 });
            aCopy.Owner.Add(contact3);

            dataAccess = new AgendaDataAccess();
            dataAccess.Modify(aCopy);

            Console.WriteLine("Agenda Modificada");
            Console.ReadKey();
            Console.WriteLine("Se va a obtener la agenda\n\n");
            Console.ReadKey();
            Agenda aCopy2 = dataAccess.Get(a.Id);

            Console.WriteLine(aCopy2.Id);
            Console.WriteLine(aCopy2.Name);

            Console.WriteLine("Contacts: \n");

            foreach (var u in aCopy2.Contacts)
            {
                Console.WriteLine(u.Name);
            }
            
            Console.WriteLine("Owners de la agenda 1: \n");
            foreach (var u in aCopy.Owner)
            {
                Console.WriteLine(u.Name);
            }
            Console.ReadKey();

        }
    }
}
