import http from "k6/http";

export default function () {
    let response = http.get("http://localhost:5263");
    console.log(response.status);
}

// k6 run --vus 10 --duration 40s k6.basic-test.js
