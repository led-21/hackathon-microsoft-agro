from azure.ai.contentsafety import ContentSafetyClient
from azure.core.credentials import AzureKeyCredential
from azure.core.exceptions import HttpResponseError
from azure.ai.contentsafety.models import AnalyzeTextOptions, TextCategory, AnalyzeImageOptions, ImageData

def content_analyze(image, text):

    # Create a Content Safety client
    client = ContentSafetyClient(CONFIG["content_moderator"]["endpoint"], AzureKeyCredential(CONFIG["content_moderator"]["key"]))

    try:
        result_image = None;
        result_text = None;    

        if image: 
           result_image = is_inapproprieate_content(client.analyze_image(AnalyzeImageOptions(image=ImageData(content=image))))

        if text:
            result_text = is_inapproprieate_content(client.analyze_text( AnalyzeTextOptions(text=text))) 

        return result_image or result_text

    except Exception as ex:
        print(f'Error when checking inappropriate content in text/image  -> {ex}')

def is_inapproprieate_content(response):
    return (next(item for item in response.categories_analysis if item.category == TextCategory.HATE).severity > 0) or \
           (next(item for item in response.categories_analysis if item.category == TextCategory.SELF_HARM).severity > 0) or \
           (next(item for item in response.categories_analysis if item.category == TextCategory.SEXUAL).severity > 0) or \
           (next(item for item in response.categories_analysis if item.category == TextCategory.VIOLENCE).severity > 0)