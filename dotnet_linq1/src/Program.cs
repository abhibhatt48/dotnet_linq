
using System;
using System.Linq;
using System.Collections.Generic;
					
public class Program
{
	
	
	
	    

    public static void Main()
	{		
		Program program = new Program();

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
		var query = employeeList.Join(salaryList,
										employee => employee.EmployeeID,
										salary => salary.EmployeeID,
										
										(employee,salary) => new 
										{
											EmployeeFirstname = employee.EmployeeFirstName,
											EmployeeLastName = employee.EmployeeLastName,
											Age = employee.Age,
											Amount = salary.Amount,
											Type = salary.Type
										})
										.OrderBy(employee => employee.EmployeeFirstname);
										foreach (var item in query)
											{
			
												Console.WriteLine("{0} - {1} - {2} - {3} - {4}", item.EmployeeFirstname, item.EmployeeLastName, item.Age, item.Amount, item.Type);
											}


		var query2 = employeeList.Join(salaryList,
                                                employee => employee.EmployeeID,
                                                salary => salary.EmployeeID,

                                                (employee, salary) => new
                                                {
                                                    EmployeeFirstname = employee.EmployeeFirstName,
                                                    EmployeeLastName = employee.EmployeeLastName,
                                                    Age = employee.Age,
                                                    Amount = salary.Amount,
													Type = salary.Type
                                                })
                                                .OrderByDescending(employee => employee.Age)
												.ThenBy(salary => salary.Type)
                                                .Skip(1)
                                                .Take(1);
											System.Console.WriteLine("\n result 2 is : \n");
												foreach (var item in query2)
											{
			
												Console.WriteLine("{0} - {1} - {2} - {3} - {4}", item.EmployeeFirstname, item.EmployeeLastName, item.Age, item.Amount, item.Type);
											}


		var query3 = employeeList.Join(salaryList,
                                                employee => employee.EmployeeID,
                                                salary => salary.EmployeeID,

                                                (employee, salary) => new
                                                {
                                                    EmployeeFirstname = employee.EmployeeFirstName,
                                                    EmployeeLastName = employee.EmployeeLastName,
                                                    Age = employee.Age,
                                                    Amount = salary.Amount
                                                })
                                                .Where(employee => employee.Age > 30 )
                                                .Skip(1);
                                                //.FirstOrDefault();
											System.Console.WriteLine("\n result 3 is : \n");
												foreach (var item in query3)
											{
													
												Console.WriteLine("{0} - {1} - {2} - {3}", item.EmployeeFirstname, item.EmployeeLastName, item.Age, item.Amount);
											}

										

										
		

		
		program.Task1();
		
		program.Task2();
		
		program.Task3();
	}
	
	public void Task1(){
		
	}
	
	public void Task2(){

	}
	
	public void Task3(){
		 //Implementation
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