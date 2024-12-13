from azure.cognitiveservices.vision.customvision.prediction import CustomVisionPredictionClient
from msrest.authentication import ApiKeyCredentials
from config import CONFIG

def analyze_image(image_contents):
    credentials = ApiKeyCredentials(in_headers={"Prediction-Key": CONFIG["custom_vision"]["prediction_key"]})
    predictor = CustomVisionPredictionClient(CONFIG["custom_vision"]["endpoint"], credentials)

    results = predictor.classify_image(CONFIG["custom_vision"]["project_id"],
                                       CONFIG["custom_vision"]["iteration_name"],
                                       image_contents)
    
    predictions = {pred.tag_name: pred.probability for pred in results.predictions}
   
    return max(predictions, key=predictions.get), max(predictions.values())