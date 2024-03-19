using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollBSI.BO;

namespace PayrollBSI.DAL.InterfaceDAL
{
    public interface IPayrollDetails
    {
		IEnumerable<PayrollDetailsBO> GetAll();
		PayrollDetailsBO GetById(int id);
		void Insert(PayrollDetailsCreateBO obj);
		void Update(PayrollDetailsBO obj);
		void Delete(int id);
		IEnumerable<PayrollDetailsBO> GetWithEmployeeName (string name);

        IEnumerable<PayrollDetailsBO> GetByEmployeeID(int id);
    }
}
