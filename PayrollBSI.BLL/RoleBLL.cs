using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollBSI.BLL.DTO;
using PayrollBSI.BLL.InterfaceBLL;
using PayrollBSI.DAL.InterfaceDAL;
using PayrollBSI.DAL;
using PayrollBSI.BO;

namespace PayrollBSI.BLL
{
	public class RoleBLL : IRoleBLL
	{
		private readonly IRoles _rolesDAL;

		public RoleBLL(IRoles rolesDAL)
		{
			_rolesDAL = rolesDAL;
		}

		public void Delete(int id)
		{
			if (id <= 0)
			{
				throw new Exception("ID is required");
			}
			try
			{
				_rolesDAL.Delete(id);
			}
			catch (Exception ex)
			{
				throw new Exception("Error DeleteRole BLL: " + ex.Message);
			}
		}


		public IEnumerable<RoleDTO> GetAll()
		{
			List<RoleDTO> listRoleDto = new List<RoleDTO>();
			var roleFromDAL = _rolesDAL.GetAll();
			foreach (var role in roleFromDAL)
			{
				listRoleDto.Add(new RoleDTO
				{
					RoleID = role.RoleID,
					RoleName = role.RoleName
				});
			}
			return listRoleDto;
		}

		public RoleDTO GetById(int id)
		{
			RoleDTO roleDto = new RoleDTO();
			var roleFromDAL = _rolesDAL.GetById(id);
			if (roleFromDAL != null)
			{
				throw new Exception($"Role with ID {id} not found.");
			}
			roleDto.RoleID = roleFromDAL.RoleID;
			roleDto.RoleName = roleFromDAL.RoleName;
			return roleDto;
		}

		public void Insert(RoleDTO obj)
		{
			try
			{
				var roleBO = new RolesBO
				{
					RoleID = obj.RoleID,
					RoleName = obj.RoleName
				};
				_rolesDAL.Insert(roleBO);
			}
			catch (Exception ex)
			{
				throw new Exception("Error InsertRole BLL: " + ex.Message);
			}
		}

		public void Update(RoleDTO obj)
		{
			try
			{
				var roleBO = new RolesBO
				{
					RoleID = obj.RoleID,
					RoleName = obj.RoleName
				};
				_rolesDAL.Update(roleBO);
			}
			catch (Exception ex)
			{
				throw new Exception("Error UpdateRole BLL: " + ex.Message);
			}
		}
	}
}
