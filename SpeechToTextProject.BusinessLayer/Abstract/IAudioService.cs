using SpeechToTextProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechToTextProject.BusinessLayer.Abstract
{
    public interface IAudioService:IGenericService<Audio>
    {
        Audio GetByAudioId(int audioId);
    }
}
