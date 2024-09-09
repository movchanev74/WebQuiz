from fastapi import FastAPI, WebSocket, WebSocketDisconnect
from fastapi.responses import HTMLResponse
from fastapi import BackgroundTasks
import os

app = FastAPI()

connected_clients = []

@app.get("/")
async def get():
    html_path = os.path.join(os.path.dirname(__file__), '..', 'index.html')
    return HTMLResponse(open(html_path).read())

@app.post("/start-quiz")
async def start_quiz():
    for client in connected_clients:
        await client.send_text("StartQuiz")
    return {"message": "StartQuiz command sent to all clients"}

@app.websocket("/ws")
async def websocket_endpoint(websocket: WebSocket):
    await websocket.accept()
    connected_clients.append(websocket)
    print("Client connected")
    try:
        while True:
            data = await websocket.receive_text()
            print(f"Message received: {data}")
    except WebSocketDisconnect:
        print("Client disconnected")
        connected_clients.remove(websocket)
    except Exception as e:
        print(f"Error: {e}")
        connected_clients.remove(websocket)
