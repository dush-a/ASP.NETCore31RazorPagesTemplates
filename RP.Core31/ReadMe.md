## You have created this project using the custom project template provided by InterData development team.

# ToDo:

After creating the project using this template there are no client side libraries in the wwwroot/lib folder. There will be only  2 validation folders with the license notes files.
The project is configured to run the Libman utility to download the necessary client-side libraries when the project starts the build process. But we only need to download those files once, not in every rebuild.
Therefore after the first build process, the project must be configured to disable libman utilty downloading the files again on build or rebuild. Just right click on the libman.json file inside solution explorer, then select 
"Disable Restore Client-Side Libraries on rebuild" context menu item.

## Validation Scripts

Also, there is one thing you should always check if you download a different version of jquery-validation files. You must update the version number in the /Shared/ _ValidationScriptsPartial.cshtml file.

https://user-images.githubusercontent.com/14074753/188157120-f47eac70-1f1c-45fc-93ab-cf2d74824522.mp4