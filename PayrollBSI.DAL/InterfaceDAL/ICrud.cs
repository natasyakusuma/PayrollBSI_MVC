using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollBSI.DAL.InterfaceDAL
{
	public interface ICrud<T>
	{
		IEnumerable<T> GetAll();
		T GetById(int id);
		void Insert(T obj);
		void Update(T obj);
		void Delete(int id);

	}
}
