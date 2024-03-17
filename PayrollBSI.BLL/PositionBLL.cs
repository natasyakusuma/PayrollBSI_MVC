using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollBSI.BLL.DTO;
using PayrollBSI.BLL.InterfaceBLL;
using PayrollBSI.BO;
using PayrollBSI.DAL;
using PayrollBSI.DAL.InterfaceDAL;

namespace PayrollBSI.BLL
{
	public class PositionBLL : IPositionBLL
	{
		public readonly IPosition _positionDAL;
		public PositionBLL()
		{
			_positionDAL = new PositionDAL();
		}
		public void Delete(int id)
		{
			if (id <= 0)
			{
				throw new ArgumentException("ID is required");
			}
			try
			{
				_positionDAL.Delete(id);
			}
			catch (Exception ex)
			{
				throw new Exception("Error DeletePosition BLL: " + ex.Message);
			}
		}

		public IEnumerable<PositionDTO> GetAll()
		{
			List<PositionDTO> listPositionDto = new List<PositionDTO>();
			var positionFromDAL = _positionDAL.GetAll();
			foreach (var position in positionFromDAL)
			{
				listPositionDto.Add(new PositionDTO
				{
					PositionID = position.PositionID,
					PositionName = position.PositionName,
					AllowanceMeal = position.AllowanceMeal,
					AllowanceTransport = position.AllowanceTransport,
					DeductionPension = position.DeductionPension,
					DeductionInsurance = position.DeductionInsurance,
					PayrateOvertime = position.PayrateOvertime,
					PayrateRegular = position.PayrateRegular
				});
			}
			return listPositionDto;
		}

		public IEnumerable<PositionDTO> GetAllActivePositions()
		{
			try
			{
				var positions = _positionDAL.GetAllActivePositions();
				var activePositions = positions.Select(p => new PositionDTO
				{
					PositionID = p.PositionID,
					PositionName = p.PositionName,
					AllowanceMeal = p.AllowanceMeal,
					AllowanceTransport = p.AllowanceTransport,
					DeductionPension = p.DeductionPension,
					DeductionInsurance = p.DeductionInsurance,
					PayrateOvertime = p.PayrateOvertime,
					PayrateRegular = p.PayrateRegular
				});
				return activePositions;
			}
			catch (Exception ex)
			{
				throw new Exception("Error GetAllActivePositions BLL: " + ex.Message);
			}
		}


		public PositionDTO GetById(int id)
		{
			PositionDTO positionDto = new PositionDTO();
			var positionFromDAL = _positionDAL.GetById(id);
			if (positionFromDAL == null)
			{
				throw new ArgumentException($"Data article with id:{id} not found");
			}
			positionDto.PositionID = positionFromDAL.PositionID;
			positionDto.PositionName = positionFromDAL.PositionName;
			positionDto.AllowanceMeal = positionFromDAL.AllowanceMeal;
			positionDto.AllowanceTransport = positionFromDAL.AllowanceTransport;
			positionDto.DeductionPension = positionFromDAL.DeductionPension;
			positionDto.DeductionInsurance = positionFromDAL.DeductionInsurance;
			positionDto.PayrateOvertime = positionFromDAL.PayrateOvertime;
			positionDto.PayrateRegular = positionFromDAL.PayrateRegular;
			return positionDto;
		}

		public void Insert(PositionDTO obj)
		{
			try
			{
				var positionBO = new PositionBO
				{
					PositionName = obj.PositionName,
					AllowanceMeal = obj.AllowanceMeal,
					AllowanceTransport = obj.AllowanceTransport,
					DeductionPension = obj.DeductionPension,
					DeductionInsurance = obj.DeductionInsurance,
					PayrateOvertime = obj.PayrateOvertime,
					PayrateRegular = obj.PayrateRegular
				};
				_positionDAL.Insert(positionBO);
			}
			catch (Exception ex)
			{
				throw new Exception("Error InsertPosition BLL: " + ex.Message);
			}
		}




		public void Update(PositionDTO obj)
		{
			try
			{
				var positionBO = new PositionBO
				{
					PositionID = obj.PositionID,
					PositionName = obj.PositionName,
					AllowanceMeal = obj.AllowanceMeal,
					AllowanceTransport = obj.AllowanceTransport,
					DeductionPension = obj.DeductionPension,
					DeductionInsurance = obj.DeductionInsurance,
					PayrateOvertime = obj.PayrateOvertime,
					PayrateRegular = obj.PayrateRegular
				};
				_positionDAL.Update(positionBO);
			}
			catch (Exception ex)
			{
				throw new Exception("Error UpdatePosition BLL: " + ex.Message);
			}
		}
	}
}
