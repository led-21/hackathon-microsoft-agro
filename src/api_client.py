import requests

API_HOST = 'http://localhost:5080'

class ApiClient:
    @staticmethod
    def classify_pest_image(image_url):
        """
        Send a request to the API to classify the pest in the image.

        Args:
            image_url (str): The URL of the image to classify.

        Returns:
            The response from the API if all OK or None otherwise.
        """
        response = requests.post("http://localhost:5080/classify_pest", params={"url": image_url})
        return response.json() if response.status_code == 200 else None
    
    @staticmethod
    def classify_pest_file(file_name, file_contents, file_type):
        """
        Send a request to the API to classify the pest in the file.

        Args:
            file_name (str): The name of the file.
            file_contents (bytes): The contents of the file.
            file_type (str): The type of the file.

        Returns:
            The response from the API if all OK or None otherwise.
        """
        files = {'file': (file_name, file_contents, file_type)}
        response = requests.post(f"{API_HOST}/classify_pest_file", files=files)
        return response.json() if response.status_code == 200 else None
    
    @staticmethod
    def get_question_answer(question):
        """
        Send a request to the API to get the answer to the question.

        Args:
            question (str): The question to ask.
        
        Returns:
            The response from the API if all OK or None otherwise.
        """
        response = requests.get(f'{API_HOST}/question/', params= {'question': question}, verify= False)
        return response.json() if response.status_code == 200 else None
    
    @staticmethod
    def get_registered_products(pest_name):
        """
        Send a request to the API to get the registered products for a pest.

        Args:
            pest_name (str): The name of the pest.
        
        Returns:
            The response from the API if all OK or None otherwise.
        """
        response = requests.get(f'{API_HOST}/get_registered_products', params= {'pest': pest_name}, verify= False)
        return response.json() if response.status_code == 200 else None

    @staticmethod
    def health_check():
        """
        Send a request to the API to check its health.
        
        Returns:
            The response from the API if all OK or None otherwise.
        """
        response = requests.get(f'{API_HOST}/health', verify= False)
        return response.json() if response.status_code == 200 else None
    
    @staticmethod
    def transcribe_audio_file(file_name, file_contents, file_type):
        """
        Send a request to the API to transcribe the audio file.

        Args:
            file_name (str): The name of the file.
            file_contents (bytes): The contents of the file.
            file_type (str): The type of the file.
        
        Returns:
            The response from the API if all OK or None otherwise
        """
        files = {'file': (file_name, file_contents, file_type)}
        response = requests.post(f"{API_HOST}/speech_to_text", files=files)
        return response.json() if response.status_code == 200 else None
