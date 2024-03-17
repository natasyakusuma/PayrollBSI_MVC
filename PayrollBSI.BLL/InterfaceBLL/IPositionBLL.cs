using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollBSI.BLL.DTO;

namespace PayrollBSI.BLL.InterfaceBLL
{
    public interface IPositionBLL
    {
        void Delete(int id);
        void Insert(PositionDTO obj);
        void Update(PositionDTO obj);
        IEnumerable<PositionDTO> GetAll();
        PositionDTO GetById(int id);
		
        IEnumerable<PositionDTO> GetAllActivePositions();
	}
}
