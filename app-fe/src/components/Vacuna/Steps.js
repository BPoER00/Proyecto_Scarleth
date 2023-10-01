"use client";
import { useVacuna } from "@/context/Vacuna.Context.js";
import { useState, useEffect } from "react";

function Steps() {
  const { changePage, paginate } = useVacuna();
  const [status, setStatus] = useState();

  useEffect(() => {
    if (paginate[0].status === "this") setStatus("List");
    if (paginate[1].status === "this") setStatus("New");
  }, [paginate]);

  return (
    <div className="mx-8 shadow rounded border h-10 mt-4 flex p-1 relative items-center dark:bg-gray-800">
      <div className="w-full flex justify-center">
        <span
          className={`${
            status === "List" ? "bg-white text-gray-800" : "text-white"
          } shadow flex items-center justify-center w-1/2 rounded-full h-8 top-[4px] absolute left-1`}
        >
          <button onClick={() => changePage(1)}>Lista De Vacuna</button>
        </span>
      </div>
      <div className="w-full flex justify-center">
        <span
          className={` ${
            status === "New" ? "bg-white text-gray-800" : "text-white"
          } shadow flex items-center justify-center w-1/2 rounded-full h-8 top-[4px] absolute right-1`}
        >
          <button onClick={() => changePage(2)}>Agregar Vacuna</button>
        </span>
      </div>
    </div>
  );
}

export default Steps;
