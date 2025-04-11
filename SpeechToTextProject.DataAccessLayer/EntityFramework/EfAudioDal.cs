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
    public class EfAudioDal : GenericRepository<Audio>, IAudioDal
    {
        public EfAudioDal(ApiContext context) : base(context)
        {
        }

        public Audio GetByAudioId(int audioId)
        {
            var context = new ApiContext();
            return context.Audios.FirstOrDefault(x => x.AudioId == audioId);
        }
    }
}
