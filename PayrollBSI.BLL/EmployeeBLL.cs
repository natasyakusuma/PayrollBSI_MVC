using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollBSI.BLL.DTO;
using PayrollBSI.BLL.InterfaceBLL;
using PayrollBSI.DAL.InterfaceDAL;
using PayrollBSI.DAL;
using AutoMapper;


namespace PayrollBSI.BLL
{
	public class EmployeeBLL : IEmployeeBLL
	{
		public readonly IEmployee _employeeDAL;
		public EmployeeBLL()
		{
			_employeeDAL = new EmployeeDAL();
		}
		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<EmployeeDTO> GetAll()
		{
			List<EmployeeDTO> listEmployeeDto = new List<EmployeeDTO>();
			var employeeFromDAL = _employeeDAL.GetAll();
			foreach (var employee in employeeFromDAL)
			{
				listEmployeeDto.Add(new EmployeeDTO
				{
					EmployeeID = employee.EmployeeID,
					FirstName = employee.FirstName,
					LastName = employee.LastName,
					RoleID = employee.RoleID,
					PositionID = employee.PositionID,
					Username = employee.Username,
					Password = employee.Password,
					IsDeleted = employee.IsDeleted,
				});
			}
			return listEmployeeDto;
		}

		public PositionDTO GetById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<EmployeeDTO> GetByRoleNameAndPositionName(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<EmployeeDTO> GetWithRoleNameAndPositionName()
		{
			var listEmployeeDto = new List<EmployeeDTO>();
			var employeeFromDAL = _employeeDAL.GetWithRoleNameAndPositionName();

			foreach (var employee in employeeFromDAL)
			{
				var employeeDto = new EmployeeDTO
				{
					EmployeeID = employee.EmployeeID,
					FirstName = employee.FirstName,
					LastName = employee.LastName,
					RoleID = employee.RoleID,
					RoleName = employee.RoleName,
					PositionID = employee.PositionID,
					PositionName = employee.PositionName,
					Username = employee.Username,
					Password = employee.Password,
					IsDeleted = employee.IsDeleted,
					AttendanceID = employee.AttendanceID,
					OvertimeHours = employee.OvertimeHours,
					RegularHours = employee.RegularHours,
					AttendanceTotal = employee.AttendanceTotal,
					Roles = employee.Roles != null ? new RoleDTO
					{
						RoleID = employee.Roles.RoleID,
						RoleName = employee.Roles.RoleName
					} : null, // Null handling for Roles property
					Position = employee.Position != null ? new PositionDTO
					{
						PositionID = employee.Position.PositionID,
						PositionName = employee.Position.PositionName
					} : null,// Null handling for Position property
					Attendance = employee.Attendances != null ? new AttendanceDTO
					{
                        AttendanceID = employee.Attendances.AttendanceID,
                        OvertimeHours = employee.Attendances.OvertimeHours,
                        RegularHours = employee.Attendances.RegularHours,
                        AttendanceTotal = employee.Attendances.AttendanceTotal
                    } : null // Null handling for Attendance property
				};

				listEmployeeDto.Add(employeeDto);
			}

			return listEmployeeDto;
		}

        public void Insert(EmployeeDTO obj)
        {
            throw new NotImplementedException();
        }

        public EmployeeDTO Login(string username, string password)
		{
			try
			{
				var employeeBO = _employeeDAL.Login(username, password);
				if (employeeBO == null)
				{
					throw new Exception("Invalid username or password");
				}

				var employeeDTO = new EmployeeDTO
				{
					EmployeeID = employeeBO.EmployeeID,
					FirstName = employeeBO.FirstName,
					LastName = employeeBO.LastName,
					RoleID = employeeBO.RoleID,
					PositionID = employeeBO.PositionID,
					Username = employeeBO.Username,
					Password = employeeBO.Password,
					IsDeleted = employeeBO.IsDeleted
				};

				return employeeDTO;
			}
			catch (Exception ex)
			{
				// Handle exception appropriately, such as logging it
				throw new Exception("Error occurred during login: " + ex.Message);
			}
		}


		public void Update(EmployeeDTO obj)
		{
			throw new NotImplementedException();
		}
	}
}
