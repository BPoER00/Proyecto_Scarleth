import axios from "axios";
import { END_POINT_API } from "@/config/props.js";
import { getCookie } from "@/config/cookieConfig.js";

const RolApi = axios.create({
  baseURL: `${END_POINT_API}/Usuario`,
  headers: {
    "Content-Type": "application/json",
    "Authorization": getCookie(),
  },
});

export const getSP = async () => {
  const res = await RolApi.get(`/GetSP`)
    .then((response) => {
      return response.data.data;
    })
    .catch((error) => {
      return error.response;
    });

  return res;
};

