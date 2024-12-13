from services.content_safety import content_analyze
from services.custom_vision import analyze_image

def process_request(image, description):

    #Content validate
    if content_analyze(image=image, text=description):
        raise ValueError("Text or image contains inappropriate content.")

    # Identification Pest
    praga_image, confidence = None, 0
    if image:
        praga_image, confidence = analyze_image(image)
    
    if description:
        praga_text = description  # Use OpenAI if necessary to interpret the description
    
    praga = praga_image if confidence >= 0.8 else praga_text

    # Continue implementation using OpenAI.

    # Return only tests
    return {
        "praga": praga
    }