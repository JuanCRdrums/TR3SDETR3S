import axios from 'axios';

export default axios.create({
    baseURL: "https://localhost:44310/api/Result",
    headers: {
        'Accept':'application/json',
        'Content-Type':'application/json',
    }
})