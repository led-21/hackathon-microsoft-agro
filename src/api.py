from fastapi import FastAPI, File, UploadFile, HTTPException, Form
from services.orchestrator import process_request

app = FastAPI()

@app.post("/analyze", summary="Get the necessary recommendations for pest control.", 
                      description="Returns necessary recommendations for pest control.")
async def analyze(
    description: str = Form(...), 
    file: UploadFile = File(...)
):
    try:
        image_content = await file.read() if file else None
        result = process_request(image=image_content, description=description)
        return result
    except ValueError as ve:
        raise HTTPException(status_code=400, detail=str(ve))
    except Exception as e:
        raise HTTPException(status_code=500, detail=str(e))

@app.get("/health")
def health_check():
    return {"status": "up"}