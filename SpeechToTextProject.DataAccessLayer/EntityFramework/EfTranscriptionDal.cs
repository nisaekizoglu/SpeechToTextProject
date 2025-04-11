using SpeechToTextProject.DataAccessLayer.Abstract;
using SpeechToTextProject.DataAccessLayer.Context;
using SpeechToTextProject.DataAccessLayer.Repositories;
using SpeechToTextProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechToTextProject.DataAccessLayer.EntityFramework
{
    public class EfTranscriptionDal : GenericRepository<Transcription>, ITranscriptionDal
    {
        public EfTranscriptionDal(ApiContext context) : base(context)
        {
        }

        public int GetTranscriptionCount()
        {
            var context=new ApiContext();
            int value = context.Transcriptions.Count();
            return value;
        }
  
    }
}
