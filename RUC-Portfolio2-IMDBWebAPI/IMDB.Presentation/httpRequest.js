const localBasePath = "https://localhost:7167/api"
const hostedBasePath = ""

export async function postData (path = '', data = {}) {
  const response = await fetch(localBasePath + path, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(data)
  });
  return response.json();
}

export async function postDataBearer (path = '', data = {}) {
  const response = await fetch(localBasePath + path, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${ JSON.parse(sessionStorage.getItem('CurrentUser')).token }`
    },
    body: JSON.stringify(data)
  });
  return response.json();
}

export async function fetchData (path = "") {
  const response = await fetch(localBasePath + path, {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json'
    },
  });
  return response.json();
}

export async function fetchDataBearer (path = "") {
  const response = await fetch(localBasePath + path, {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${ JSON.parse(sessionStorage.getItem('CurrentUser')).token }`
    },
  });
  return response.json();
}
