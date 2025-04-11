using SpeechToTextProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechToTextProject.DataAccessLayer.Abstract
{
    public interface ITranscriptionDal:IGenericDal<Transcription>
    {
        int GetTranscriptionCount();
        
    }
}
