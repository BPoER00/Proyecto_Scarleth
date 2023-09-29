import React, { useEffect } from "react";
import InputSelect from "../Inputs/InputSelect";
import { useForm } from "react-hook-form";
import { useVacuna } from "@/context/Vacuna.Context";

function Filtros({ setFiltros }) {
  const { vacuna } = useVacuna();
  const {
    formState: { errors },
    control,
    watch,
    reset
  } = useForm();

  const vacunaId = (watch("vacuna_id") || 0).toString();

  useEffect(() => {
    const filtros = {
      vacunaId,
    };

    setFiltros(filtros);
  }, [vacunaId]);

  const handleReset = async () => {
    reset();
  };

  return (
    <div className="px-8 pt-6 pb-4 mb-1 dark:bg-gray-800 rounded">
      <div className="flex flex-wrap -mx-4">
        <div className="w-11/12 px-4 mb-4">
          <InputSelect
            label={"Nombre Vacuna"}
            name={"vacuna_id"}
            options={vacuna}
            control={control}
            placeholder={"Nombre Vacuna..."}
            errors={errors.asignacion_id?.message}
          />
        </div>
        <div className="w-full text-right px-4">
          <button
            type="button"
            className="bg-red-500 hover:bg-red-600 text-white font-bold py-2 px-4 rounded"
            onClick={handleReset}
          >
            Limpiar Campos
          </button>
        </div>
      </div>
    </div>
  );
}

export default Filtros;
