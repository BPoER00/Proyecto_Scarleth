import cookie from "js-cookie";
import { SECRET_KEY_COOKIE } from '../config/props.js'

export const postCookie = (data) => {
  cookie.set(SECRET_KEY_COOKIE, data, {
    expires: 1,
    secure: true,
    sameSite: "strict",
  });
};

export const getCookie = () => {
  return cookie.get(SECRET_KEY_COOKIE);
};

export const deleteCookie = () => {
  cookie.set(SECRET_KEY_COOKIE, null, {
    expires: 0,
    secure: true,
    sameSite: "strict",
  });
};