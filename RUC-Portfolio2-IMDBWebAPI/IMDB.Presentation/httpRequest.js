const localBasePath = "https://localhost:7167/api"
const hostedBasePath = ""

export async function postData(path = '', data = {}) {
  const response = await fetch(localBasePath + path , {
    method: 'POST', // *GET, POST, PUT, DELETE, etc.
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(data)
  });
  return response.json();
}