using log4net;

namespace ImageCompressor.Business.Util
{
    public class LogUtil
    {
        private static LogUtil logUtil;
        private LogUtil()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static LogUtil GetInstance()
        {
            if (logUtil == null)
            {
                logUtil = new LogUtil();
            }

            return logUtil;
        }
        public ILog GetLogger(string name)
        {
            return log4net.LogManager.GetLogger(name);
        }
    }
}
