import axios from "axios";
import { END_POINT_API } from "@/config/props.js";
import { postCookie } from "@/config/cookieConfig.js";

const LoginApi = axios.create({
  baseURL: `${END_POINT_API}/Login`,
  headers: {
    "Content-Type": "application/json",
  },
});

export const post = async (data) => {
  const res = await LoginApi.post(`/Post`, data)
    .then((response) => {
      if (response.status === 200) postCookie(response.data.data);
      return response;
    })
    .catch((error) => {
      return error.response;
    });

  return res;
};
