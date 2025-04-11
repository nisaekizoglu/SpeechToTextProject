using SpeechToTextProject.BusinessLayer.Abstract;
using SpeechToTextProject.DataAccessLayer.Abstract;
using SpeechToTextProject.DataAccessLayer.EntityFramework;
using SpeechToTextProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechToTextProject.BusinessLayer.Concrete
{
    public class AudioManager : IAudioService
    {
        private readonly IAudioDal _audioDal;

        public AudioManager(IAudioDal audioDal)
        {
            _audioDal = audioDal;
        }

        public Audio GetByAudioId(int audioId)
        {
            return _audioDal.GetByAudioId(audioId);
        }

        public void TDelete(int id)
        {
            _audioDal.Delete(id);   
        }

        public List<Audio> TGetAll()
        {
            return _audioDal.GetAll();
        }

        public Audio TGetById(int id)
        {
            return _audioDal.GetById(id);
        }

        public void TInsert(Audio entity)
        {
            _audioDal.Insert(entity);
        }

        public void TUpdate(Audio entity)
        {
           _audioDal.Update(entity);
        }
    }
}
