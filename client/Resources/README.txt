﻿==========================================
Readme created 10/06/18
Josh Perkins
==========================================

Log:
------------------------------------------

10/13/18 - Didn't realize initially when creating the project that I was making everything tightly coupled. When I
went to do some testing yesterday I realized I couldn't. That's what sparked the rewrite that got finished today. Now
everything is loosely coupled.

10/14/18 - Building tests for this is much more involved than previous work.


Additional Features:
------------------------------------------
AutoSave: Accessible via File -> Enable AutoSave. This will toggle the instance's ability to automatically save. If the
spreadsheet is not initially saved then the user will be prompted to save.

Cut/Copy/Paste: Accesssible via the Edit menu or by right clicking on the spreadsheet panel. These operations will
modify the curently selected cell. When pasting from one cell to another the evaluated value of the previous cell will
be pasted into the current cell.

Dark Theme: Accessible via View -> Dark Mode. This will toggle the instance's theme between "light" and "dark".

Notes:
------------------------------------------
When viewing the "Navigating Cells" help menu, the provided images are animated. When I created the animations I made
the start of them slightly long.

There's no special requirements when building this solution even though SpreadsheetPanel has been customized and is
included as a subproject. I've added a post-build action to copy its built DLL's over to the Resources/Library folder
after it completes building.