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
            return _data.MusicListRepository.GetByFilter(x => x.Id == MusicId);
        }
        public static List<MusicList> GetMusicLists()
        {
            return _data.MusicListRepository.GetAll(x => x.User, y => y.IsComplete == false && y.ConfirmId == 1);
        }
        public static List<MusicList> GetMusicLists(int UserId)
        {
            return _data.MusicListRepository.GetAll(x => x.User, y => y.UserId == UserId && y.IsComplete == false && y.ConfirmId == 1);
        }
    }
}
