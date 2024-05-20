import ollama
import sys
from PySide6.QtWidgets import QApplication, QLabel, QVBoxLayout, QWidget, QPushButton, QLineEdit, QScrollArea
from PySide6.QtCore import QObject, Signal, Qt

class Communicate(QObject):
    # Define a signal that carries a string
    data_ready = Signal(str)

class MyWindow(QWidget):
    def __init__(self):
        super().__init__()
        self.initUI()

    def initUI(self):
        layout = QVBoxLayout()
        self.edit = QLineEdit("")
        self.label = QLabel("")
        self.button = QPushButton("Generate")
        self.button.clicked.connect(self.sendData)

        self.label.maximumWidth()

        layout.addWidget(self.edit)
        layout.addWidget(self.button)
        layout.addWidget(self.label)

        self.setLayout(layout)

    def receiveData(self, data):
        # Update the label with the received data
        self.label.setText(data)

    def sendData(self):
        # Simulate sending data from code
        response = ollama.chat(model='gemma', messages=[
          {
            'role': 'user',
            'content': self.edit.text(),
          },
        ])
        # Emit the signal with the data
        self.communicate.data_ready.emit(response['message']['content'])

if __name__ == '__main__':
    app = QApplication(sys.argv)
    window = MyWindow()

    # Create an instance of the communication object
    window.communicate = Communicate()
    # Connect the signal to the method that will handle it
    window.communicate.data_ready.connect(window.receiveData)

    window.setWindowTitle("Data Receiver")
    window.setGeometry(100, 100, 800, 400)
    window.setFixedWidth(400)
    window.show()
    sys.exit(app.exec_())