from tkinter import *
from tkinter import ttk

root = Tk()
root.title("Álomváros")

mainframe = ttk.Frame(root, padding="10 10 10 10")
mainframe.grid(column=0, row=0, sticky=(N, W, E, S))
root.columnconfigure(0, weight=1)
root.rowconfigure(0, weight=1)

ttk.Label(mainframe, text="ÁLOMVÁROS").grid(column=2,row=2)

root.mainloop()