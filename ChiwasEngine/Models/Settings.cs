using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChiwasEngine.Models
{
    public interface ISettings
    {
        GeneralSettings General { get; }
        void Save();
    }

    public class Settings : ISettings
    {
        // 1
        private readonly Lazy<GeneralSettings> _generalSettings;
        // 2
        public GeneralSettings General { get { return _generalSettings.Value; } }

        private readonly IChiwasEngineContext _unitOfWork;
        public Settings(IChiwasEngineContext unitOfWork)
        {
            // ARGUMENT CHECKING SKIPPED FOR BREVITY
            _unitOfWork = unitOfWork;
            // 3
            _generalSettings = new Lazy<GeneralSettings>(CreateSettings<GeneralSettings>);
        }

        public void Save()
        {
            // only save changes to settings that have been loaded
            if (_generalSettings.IsValueCreated)
                _generalSettings.Value.Save(_unitOfWork);

            _unitOfWork.SaveChanges();
        }
        // 4
        private T CreateSettings<T>() where T : SettingsBase, new()
        {
            var settings = new T();
            settings.Load(_unitOfWork);
            return settings;
        }
    }
}