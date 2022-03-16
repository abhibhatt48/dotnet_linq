
using System;
using System.Linq;
using System.Collections.Generic;
					
public class Program
{

	IList <Employee> employeeList  = new List<Employee>() { 
			new Employee(){ EmployeeID = 1, EmployeeFirstName = "Rajiv", EmployeeLastName = "Desai", Age = 49},
			new Employee(){ EmployeeID = 2, EmployeeFirstName = "Karan", EmployeeLastName = "Patel", Age = 32},
			new Employee(){ EmployeeID = 3, EmployeeFirstName = "Sujit", EmployeeLastName = "Dixit", Age = 28},
			new Employee(){ EmployeeID = 4, EmployeeFirstName = "Mahendra", EmployeeLastName = "Suri", Age = 26},
			new Employee(){ EmployeeID = 5, EmployeeFirstName = "Divya", EmployeeLastName = "Das", Age = 20},
			new Employee(){ EmployeeID = 6, EmployeeFirstName = "Ridhi", EmployeeLastName = "Shah", Age = 60},
			new Employee(){ EmployeeID = 7, EmployeeFirstName = "Dimple", EmployeeLastName = "Bhatt", Age = 53}			
		};
        IList <Salary> salaryList  = new List<Salary>() {
			new Salary(){ EmployeeID = 1, Amount = 1000, Type = SalaryType.Monthly},
			new Salary(){ EmployeeID = 1, Amount = 500, Type = SalaryType.Performance},
			new Salary(){ EmployeeID = 1, Amount = 100, Type = SalaryType.Bonus},
			new Salary(){ EmployeeID = 2, Amount = 3000, Type = SalaryType.Monthly},
			new Salary(){ EmployeeID = 2, Amount = 1000, Type = SalaryType.Bonus},
			new Salary(){ EmployeeID = 3, Amount = 1500, Type = SalaryType.Monthly},
			new Salary(){ EmployeeID = 4, Amount = 2100, Type = SalaryType.Monthly},
			new Salary(){ EmployeeID = 5, Amount = 2800, Type = SalaryType.Monthly},
			new Salary(){ EmployeeID = 5, Amount = 600, Type = SalaryType.Performance},
			new Salary(){ EmployeeID = 5, Amount = 500, Type = SalaryType.Bonus},
			new Salary(){ EmployeeID = 6, Amount = 3000, Type = SalaryType.Monthly},
			new Salary(){ EmployeeID = 6, Amount = 400, Type = SalaryType.Performance},
			new Salary(){ EmployeeID = 7, Amount = 4700, Type = SalaryType.Monthly}
		};
	
	
	
	    

    public static void Main()
	{		
		Program program = new Program();
	
		program.Task1();
		
		program.Task2();
		
		program.Task3();
	}
	
	public void Task1()
	{

		System.Console.WriteLine("\n task 1 is : \n");
                    
        var sumsalary = from salary in this.salaryList
                          group salary by salary.EmployeeID
                          into sal
                          select new{
                            EmployeeID = sal.Key,
                            Sum = sal.Sum( s => s.Amount )
                            };
                    
        var query =from employee in this.employeeList
                    join salary in sumsalary
                      on employee.EmployeeID
                      equals
                      salary.EmployeeID
                    orderby employee.EmployeeFirstName
                    select new{
                          e = employee,
                          salary = salary.Sum,
                      };
                      
                
        foreach (var item in query)
        {     try{
                Console.WriteLine($" Name: {item.e.EmployeeFirstName} {item.e.EmployeeLastName}, Salary: {item.salary} , {item.e.Age}  ");
                 }
				 
				 catch(Exception e)
				 {
                   System.Console.WriteLine("Exception XXXXXX");
                 }        
        }
		
	}
	
	public void Task2()
	{

		System.Console.WriteLine("\n task 2 is : \n");
        
        
        var ms = from salary in this.salaryList
                            where salary.Type == SalaryType.Monthly 
                            select salary;

       var query2 = from salary in ms
                      join employee in this.employeeList
                             on salary.EmployeeID
                             equals
                             employee.EmployeeID
                      orderby employee.Age descending
                      select new{
                            salary,
                            employee
                               };

        foreach (var item in query2.Skip(1).Take(1))
        {
                try{
                    Console.WriteLine($" EmployeeID: {item.employee.EmployeeID}, Name: {item.employee.EmployeeFirstName} {item.employee.EmployeeLastName}, Age: {item.employee.Age}, Salary: {item.salary.Amount}");
                   Console.WriteLine();
                }
				
				catch(Exception e)
				{
                             Console.WriteLine("exception : XXXXX");
                }
        }
	}
	
	public void Task3(){

		System.Console.WriteLine("\n task 3 is : \n");


		  var means = from salary in this.salaryList
                      group salary by salary.EmployeeID
                      into sal
                      select new{
                        EmployeeID = sal.Key,
                        amt = sal.Average( s => s.Amount)
                     };

        var grou_p = (from employee in employeeList
                     where employee.Age > 30 
                     select employee);
        
        var query3 = from employee in grou_p
                      join salary in means
                        on employee.EmployeeID
                        equals
                        salary.EmployeeID
                      orderby employee.EmployeeFirstName 
                      select new{
                          emp = employee,
                          avg = salary.amt
                      };

        foreach (var item in query3)
        {   
            Console.WriteLine($" EmployeeID: {item.emp.EmployeeID}, Name: {item.emp.EmployeeFirstName} {item.emp.EmployeeLastName}, Age: {item.emp.Age},  Mean salary: {item.avg:N1}");
            
        }   
        }

	}

public enum SalaryType{
	Monthly,
	Performance,
	Bonus
}

public class Employee{
	public int EmployeeID { get; set; }
	public string EmployeeFirstName { get; set; }
	public string EmployeeLastName { get; set; }
	public int Age { get; set; }	
}

public class Salary{
	public int EmployeeID { get; set; }
	public int Amount { get; set; }
	public SalaryType Type { get; set; }
}