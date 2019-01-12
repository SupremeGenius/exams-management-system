import axios from "axios";

const setAuthToken = (token,token_type) => {
    if(token){
        // Appy to every request
        axios.defaults.headers.common['Authorization'] =  token_type + " " + token;
    } else {
        // Delete Auth Header
        delete axios.defaults.headers.common['Authorization'];
    }
}

export default setAuthToken;