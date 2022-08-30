# WCL_AutoLogger

Set this program to run on login/boot, by using task scheduler
<img width="707" alt="image" src="https://user-images.githubusercontent.com/29127320/187520079-244a72f7-97da-47db-aef4-cfb012e0a031.png">

Then make sure it run as if its logged in or not, this will cause it to run as hidden
![image](https://user-images.githubusercontent.com/29127320/187520254-d1b838c1-40ab-4dd2-8934-859f3b08bb0d.png)

On Action add the program with 2 arguments, first is the path to the WCL exe, 2nd is to the log file

`"C:\Program Files\Warcraft Logs Uploader\Warcraft Logs Uploader.exe" "C:\Games\World of Warcraft\_retail_\Logs\WoWCombatLog.txt"`

It will delete the log file if it exists when wow.exe have stopped running

It will log the logs as such:
<img width="412" alt="image" src="https://user-images.githubusercontent.com/29127320/187521834-96158624-e119-43f0-ba9d-16971e3d797c.png">
