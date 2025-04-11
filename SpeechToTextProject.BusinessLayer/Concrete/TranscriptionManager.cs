using Microsoft.Extensions.Configuration;
using SpeechToTextProject.BusinessLayer.Abstract;
using SpeechToTextProject.DataAccessLayer.Abstract;
using SpeechToTextProject.EntityLayer.Concrete;
using System;
using System.IO;
using System.Threading.Tasks;


namespace SpeechToTextProject.BusinessLayer.Concrete
{
    public class TranscriptionManager : ITranscriptionService
    {
        private readonly ITranscriptionDal _transcriptionDal;

        public TranscriptionManager(ITranscriptionDal transcriptionDal)
        {
            _transcriptionDal = transcriptionDal;
        }

        public void TDelete(int id)
        {
            _transcriptionDal.Delete(id);
        }

        public List<Transcription> TGetAll()
        {
            return _transcriptionDal.GetAll();
        }

        public Transcription TGetById(int id)
        {
            return _transcriptionDal.GetById(id);
        }

        public int TGetTranscriptionCount()
        {
            return _transcriptionDal.GetTranscriptionCount();
        }

        public void TInsert(Transcription entity)
        {
            _transcriptionDal.Insert(entity);
        }

        public void TUpdate(Transcription entity)
        {
            _transcriptionDal.Update(entity);
        }

    }

}

