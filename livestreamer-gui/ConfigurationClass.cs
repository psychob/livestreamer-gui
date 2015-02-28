namespace livestreamer_gui
{
 public struct UsedUrls
 {
  public string url;
  public uint count;

  public UsedUrls( string p )
  {
   url = p;
   count = 1;
  }
 }

 public class ConfigurationClass
 {
  public string livestreamerPath;
  public int livestreamerLogLevel;
  public bool retry;
  public int retryCount;
  public int retryDelay;
  public bool dontShowConsole;
  public bool generateVlcMetadata;
  public UsedUrls[] usedUrls;
 }
}
