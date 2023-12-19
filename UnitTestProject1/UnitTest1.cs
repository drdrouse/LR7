using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Telephone_Directory;

namespace UnitTestProject1
{
    [TestClass()]
    public class UnitTest1
    {
        public List<Users> Users_Directory = new List<Users>();
        int id_delete, id_change=0;
        Random _rnd = new Random();
        Directory directory = new Directory();
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public  void Initialize()
        {
            Users_Directory.Add(new Users(1, "Павлов", "Михаил", "Романович", "7(296)018-07-61", "jadouwittudou-9303@yopmail.com", true));
            Users_Directory.Add(new Users(2, "Шевцов", "Василиса", "Кирилловна", "7(324)813-49-73", "vellupezauje-9469@yopmail.com", false));
            Users_Directory.Add(new Users(3, "Дмитриева", "Александра", "Тимофеевна", "7(835)590-88-78", "jaujetoinnougeu-1691@yopmail.com", true));
            Users_Directory.Add(new Users(4, "Рыжков", "Арсений", "Александрович", "7(705)157-31-54", "rihequefrellou-4880@yopmail.com", true));

            id_delete = _rnd.Next(0, 10);
            id_change = _rnd.Next(0, 10);

            //id_delete = Convert.ToInt32(TestContext.DataRow["id_delete"]);
            //id_change  = Convert.ToInt32(TestContext.DataRow["id_change"]);

            Debug.WriteLine($"ID для удаления: {id_delete}\n" +
                $"ID для изменения: {id_change}\n");
            for (int i = 0; i < Users_Directory.Count; i++)
            {
                if (Users_Directory[i] != null)
                    Debug.WriteLine($"{Users_Directory[i].idUser}\t\t{Users_Directory[i].surname}\t\t" +
                        $"{Users_Directory[i].name}\t\t{Users_Directory[i].secondname}\t\t{Users_Directory[i].phoneNumber}" +
                        $"\t\t{Users_Directory[i].email}\t\t{Users_Directory[i].blocked}");
                else
                    Debug.WriteLine("NOTHING");
            }
        }

        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "Param", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestMethod_Delete()
        {     
            Assert.IsTrue(directory.Delete(id_delete, Users_Directory));

            Debug.WriteLine("\n");
            for (int i = 0; i < Users_Directory.Count; i++)
            {
                if (Users_Directory[i] != null)
                    Debug.WriteLine($"{Users_Directory[i].idUser}\t\t{Users_Directory[i].surname}\t\t" +
                        $"{Users_Directory[i].name}\t\t{Users_Directory[i].secondname}\t\t{Users_Directory[i].phoneNumber}" +
                        $"\t\t{Users_Directory[i].email}\t\t{Users_Directory[i].blocked}");
                else
                    Debug.WriteLine("NOTHING");
            }
        }

        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "Param", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestMethod_Add()
        {
            Assert.IsTrue(directory.Add("Иванов", "Иван", "Иванович", "7(000)000-00-00", "test@mail.com", Users_Directory));
            
            Debug.WriteLine("\n");
            for (int i = 0; i < Users_Directory.Count; i++)
            {
                if (Users_Directory[i] != null)
                    Debug.WriteLine($"{Users_Directory[i].idUser}\t\t{Users_Directory[i].surname}\t\t" +
                        $"{Users_Directory[i].name}\t\t{Users_Directory[i].secondname}\t\t{Users_Directory[i].phoneNumber}" +
                        $"\t\t{Users_Directory[i].email}\t\t{Users_Directory[i].blocked}");
                else
                    Debug.WriteLine("NOTHING");
            }
        }

        [TestMethod]
        public void TestMethod_Change()
        {
            Assert.IsTrue(directory.Change(Users_Directory, "Фамилия", "Иванов", id_change));
            Debug.WriteLine("\n");
            for (int i = 0; i < Users_Directory.Count; i++)
            {
                if (Users_Directory[i] != null)
                    Debug.WriteLine($"{Users_Directory[i].idUser}\t\t{Users_Directory[i].surname}\t\t" +
                        $"{Users_Directory[i].name}\t\t{Users_Directory[i].secondname}\t\t{Users_Directory[i].phoneNumber}" +
                        $"\t\t{Users_Directory[i].email}\t\t{Users_Directory[i].blocked}");
                else
                    Debug.WriteLine("NOTHING");
            }
        }

        [TestCleanup]
        public void GC()
        {
            id_delete = id_change = 0;
            Users_Directory.Clear();
        }
    }
}
