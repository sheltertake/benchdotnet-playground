using System;
using System.Buffers;
using System.Collections.Generic;

namespace StructVsClassLib
{
    public class StructVsClass
    {
        private SomeService service = new SomeService();
        private LocationService locationService = new LocationService();

        public List<string> PeopleEmployeedWithinLocation_Classes(int amount)
        {
            LocationClass location = new LocationClass();
            List<string> result = new List<string>();
            List<PersonDataClass> input = service.GetPersonsInBatchClasses(amount);
            DateTime now = DateTime.Now;
            for (int i = 0; i < input.Count; ++i)
            {
                PersonDataClass item = input[i];
                if (now.Subtract(item.BirthDate).TotalDays > 18 * 365)
                {
                    var employee = service.GetEmployeeClass(item.EmployeeId);
                    if (locationService.DistanceWithClass(location, employee.Address) < 10.0)
                    {
                        string name = string.Format("{0} {1}", item.Firstname, item.Lastname);
                        result.Add(name);
                    }
                }
            }
            return result;
        }
        public List<string> PeopleEmployeedWithinLocation_Structs(int amount)
        {
            
            LocationStruct location = new LocationStruct();
            List<string> result = new List<string>();
            InputDataStruct[] input = service.GetPersonsInBatchStructs(amount);
            DateTime now = DateTime.Now;
            for (int i = 0; i < input.Length; ++i)
            {
                ref InputDataStruct item = ref input[i];
                if (now.Subtract(item.BirthDate).TotalDays > 18 * 365)
                {
                    var employee = service.GetEmployeeStruct(item.EmployeeId);
                    if (locationService.DistanceWithStruct(ref location, employee.Address) < 10.0)
                    {
                        string name = string.Format("{0} {1}", item.Firstname, item.Lastname);
                        result.Add(name);
                    }
                }
            }
            return result;
        }

        public List<string> PeopleEmployeedWithinLocation_ArrayPoolStructs(int amount)
        {
            LocationStruct location = new LocationStruct();
            List<string> result = new List<string>();
            InputDataStruct[] input = service.GetDataArrayPoolStructs(amount);
            DateTime now = DateTime.Now;
            for (int i = 0; i < input.Length; ++i)
            {
                ref InputDataStruct item = ref input[i];
                if (now.Subtract(item.BirthDate).TotalDays > 18 * 365)
                {
                    var employee = service.GetEmployeeStruct(item.EmployeeId);
                    if (locationService.DistanceWithStruct(ref location, employee.Address) < 10.0)
                    {
                        string name = string.Format("{0} {1}", item.Firstname, item.Lastname);
                        result.Add(name);
                    }
                }
            }
            ArrayPool<InputDataStruct>.Shared.Return(input);
            return result;
        }

    }
    public class LocationService
    {
        internal double DistanceWithClass(LocationClass location, string address)
        {
            return 1.0;
        }

        internal double DistanceWithStruct(ref LocationStruct location, string address)
        {
            return 1.0;
        }
    }

    public class SomeService
    {
        internal InputDataStruct[] GetDataArrayPoolStructs(int amount)
        {
            InputDataStruct[] result =  ArrayPool<InputDataStruct>.Shared.Rent(amount);
            for (int i = 0; i < amount; ++i)
            {
                result[i] = new InputDataStruct()
                {
                    Firstname = "A",
                    Lastname = "B",
                    BirthDate = DateTime.Now.AddYears(-20),
                    EmployeeId = Guid.NewGuid()
                };
            }
            
            return result;
        }

        internal List<PersonDataClass> GetPersonsInBatchClasses(int amount)
        {
            List<PersonDataClass> result = new List<PersonDataClass>(amount);
            for (int i = 0; i < amount; ++i)
            {
                result.Add(new PersonDataClass()
                {
                    Firstname = "A",
                    Lastname = "B",
                    BirthDate = DateTime.Now.AddYears(-20),
                    EmployeeId = Guid.NewGuid()
                });
            }
            return result;
        }
        internal InputDataStruct[] GetPersonsInBatchStructs(int amount)
        {
            InputDataStruct[] result = new InputDataStruct[amount];
            for (int i = 0; i < amount; ++i)
            {
                result[i] = new InputDataStruct()
                {
                    Firstname = "A",
                    Lastname = "B",
                    BirthDate = DateTime.Now.AddYears(-20),
                    EmployeeId = Guid.NewGuid()
                };
            }
            return result;
        }

        internal EmployeeClass GetEmployeeClass(Guid employeeId)
        {
            return new EmployeeClass() { Address = "X", Name = "Y" };
        }
        internal EmployeeStruct GetEmployeeStruct(Guid employeeId)
        {
            return new EmployeeStruct() { Address = "X", Name = "Y" };
        }
    }
    public class PersonDataClass
    {
        public string Firstname;
        public string Lastname;
        public DateTime BirthDate;
        public Guid EmployeeId;
    }
    public struct InputDataStruct
    {
        public string Firstname;
        public string Lastname;
        public DateTime BirthDate;
        public Guid EmployeeId;
    }
    public class LocationClass
    {
        public double Lat;
        public double Long;
    }

    public struct LocationStruct
    {
        public double Lat;
        public double Long;
    }

    public class EmployeeClass
    {
        public string Name;
        public string Address;
    }
    public struct EmployeeStruct
    {
        public string Name;
        public string Address;
    }
}
