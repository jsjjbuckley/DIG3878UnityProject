# DIG3878UnityProject
Repo for DIG 3878 Unity Group Project

How to Use GitHub

To Clone Repo:
    Go to a directory(folder) that you want your project to be in.
    Open a terminal to this directory.
    In the terminal type:
        git clone https://github.com/jsjjbuckley/DIG3878UnityProject.git
    Then in the terminal type:
        cd DIG3878UnityProject
    Now you are in the directory where you can see everything the way you would from the master branch on the github website.

To Create New Branch:
    Anytime you want to make something new you should put it in a different branch first, for safety. To create a new branch you can do the following:
        1. Type in the branch name on the github website 
        2. OR in terminal type:
            git checkout -b [Name of your branch (Don't include brackets)]
    
    On your local machine, to be sure you are on the right branch you can use:
        git checkout [Name of existing branch(Don't include brackets)] 
    This will put you in the branch you want to be in.

To Pull:
    Once you have gone to the branch you want to be in, you may see that the code you see on the GitHub website is not showing on your local machine. This is because you need to pull the code from GitHub. To do this, in your terminal type:
        git pull origin (name of branch you want code from).
    You should now see the code on your machine.

To Push:
    In GitHub, any time you want to put your code onto GitHub and not just your local machine you need to push. When your code is ready to push, there will be a couple steps you need to take. 
    First, you will need to tell your terminal what you want pushed. In order to push all the files you have changed, in your terminal type:
        git add .
    Then you need to write a commit message saying what changes you made, this should be a brief message. In your terminal type:
        git commit -m "[Your message here (No brackets but need parantheses)]"
    Lastly, to actually push to GitHub you need to then type in the terminal:
        git push origin [Name of branch (no brackets)]
    That's all you need to do.

If you're not comfortable using the terminal there are other ways to do these functions in GitHub. 

Some additional tutorials:
    https://towardsdatascience.com/getting-started-with-git-and-github-6fcd0f2d4ac6

    https://www.elegantthemes.com/blog/resources/git-and-github-a-beginners-guide-for-complete-newbies
    
    Cloning a repo:
    https://help.github.com/en/github/creating-cloning-and-archiving-repositories/cloning-a-repository

        