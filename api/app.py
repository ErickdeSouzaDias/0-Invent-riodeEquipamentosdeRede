from flask import Flask
import sqlite3

app = Flask(__name__)

conexao = sqlite3.connect('..\\..\\0-InventáriodeEquipamentosdeRede\\Dados.db')

cursor = conexao.cursor()

try:
    cursor.execute("select * from equipamentos")
    resultados = cursor.fetchall()
except sqlite3.Error as e:
    print(f"Error: {e}")

@app.route("/")
def hello():
    return str(resultados)

if __name__ == "__main__":
    app.run(debug=True)