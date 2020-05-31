using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Operations
{
    public class TableOperation : BaseOperation
    {
        public static int TableAdd(Table table)
        {
            _data.TableRepository.Add(table);
            return _data.Complete();
        }
        public static int TableUpdate(Table table)
        {
            _data.TableRepository.Update(table);
            return _data.Complete();
        }
        public static int TableRemove(int id)
        {
            _data.TableRepository.Remove(id);
            return _data.Complete();
        }
        public static Table GetTable(int id)
        {
            return _data.TableRepository.GetById(id);
        }
        public static List<Table> GetTables()
        {
            return _data.TableRepository.GetAll();
        }
        public static List<Table> GetAllWaitTable()
        {
            return _data.TableRepository.GetAll(x => x.User, x => x.ConfirmId == 3);
        }
        public static int TableApproved(int id)
        {
            var _table = _data.TableRepository.GetById(id);
            _table.ConfirmId = 1;
            _data.TableRepository.Update(_table);
            return _data.Complete();
        }
        public static int TableConfirmRemove(int id)
        {

            var _table = _data.TableRepository.GetById(id);
            _table.ConfirmId = 5;
            _data.TableRepository.Update(_table);
            return _data.Complete();
        }
    }
}
