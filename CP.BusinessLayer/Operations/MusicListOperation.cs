using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Operations
{
    public class MusicListOperation : BaseOperation
    {
        public static int MusicAdd(MusicList musicList)
        {
            _data.MusicListRepository.Add(musicList);
            return _data.Complete();
        }
        public static int MusicUpdate(MusicList musicList)
        {
            _data.MusicListRepository.Update(musicList);
            return _data.Complete();
        }
        public static int MusicRemove(int MusicId)
        {
            _data.MusicListRepository.Remove(MusicId);
            return _data.Complete();
        }
        public static MusicList MusicListFind(int MusicId)
        {
            return _data.MusicListRepository.GetByFilter(x => x.Id == MusicId && x.IsDeleted == false);
        }
        public static List<MusicList> GetMusicLists()
        {
            return _data.MusicListRepository.GetAll(x => x.User, y => y.ConfirmId == 2 && y.IsDeleted == false);
        }
        public static List<MusicList> GetMusicLists(int UserId)
        {
            return _data.MusicListRepository.GetAll(x => x.User, y => y.UserId == UserId && y.ConfirmId == 2 && y.IsDeleted == false);
        }
        public static void RemoveAll(int UserId)
        {
            var _lists = GetMusicLists(UserId);
            foreach (var list in _lists)
            {
                _data.MusicListRepository.Remove(list.Id);
            }
            _data.Complete();
        }
        public static void ConfirmAll(int UserId)
        {
            var _lists = GetMusicLists(UserId);
            foreach (var list in _lists)
            {
                var item = MusicListFind(list.Id);
                item.ConfirmId = 3;
                MusicUpdate(item);
            }
            _data.Complete();
        }
        public static List<MusicList> GetHistoryList(int UserId)
        {
            return _data.MusicListRepository.GetAll(null, x => x.UserId == UserId && x.ConfirmId == 4);
        }
        public static List<MusicList> GetAllWaitMusic()
        {
            return _data.MusicListRepository.GetAll(null, x => x.ConfirmId == 3 && x.IsDeleted == false);
        }
    }
}
