from tkinter import *
from tkinter import messagebox  

def Warning():
    res = messagebox.askquestion('Exit Application', 'Do you really want to exit?')
    if res == 'yes':
        root.destroy()

root = Tk()
root.attributes('-fullscreen', True)

quit = Button(root, text="Quit", bg="#D32F2F", fg="white", font=("Arial", 14, "bold"), height=3, width=10, command=Warning)
quit.place(x=100, y=1300)  

root.mainloop()
