import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { ValidateDetalleVacuna } from "@/validations/DetalleVacuna.Validation";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import InputText from "../Inputs/InputText";
import { useVacuna } from "@/context/Vacuna.Context";

function ActionModal({ idVacuna, action }) {
  const { insertDetalle } = useVacuna();

  const sleep = (ms) => {
    return new Promise((resolve) => setTimeout(resolve, ms));
  };

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(ValidateDetalleVacuna),
  });

  const onSubmit = async (e) => {
    const vacuna = {
      descripcion: e.descripcion,
      cantidad: e.cantidad,
      fecha_vencimiento: e.fecha_vencimiento,
      vacuna_id: idVacuna,
    };

    const res = await insertDetalle(vacuna);

    console.log(res);
    if (res.data === true) {
      toast.success("Se Ingreso la vacuna correctamente");
      await sleep(3000);
      action();
    } else if (res.status === 400 || res.status === 401) {
      toast.warning(`Error ${res.data.message}`);
    } else if (res.status === 500) {
      toast.warning("Error al guardar la vacuna");
    }
  };

  return (
    <>
      <ToastContainer />
      <form
        onSubmit={handleSubmit(onSubmit)}
        className="px-8 pt-6 pb-8 mb-4 dark:bg-gray-900 rounded"
      >
        <div className="mb-4">
          <InputText
            label={"Descripcion"}
            name={"descripcion"}
            type={"text"}
            placeholder={"Ingrese Descripcion..."}
            register={register}
            errors={errors.descripcion?.message}
          />
        </div>

        <div className="mb-4">
          <InputText
            label={"Cantidad"}
            name={"cantidad"}
            type={"text"}
            placeholder={"Ingrese Cantidad..."}
            register={register}
            errors={errors.cantidad?.message}
          />
        </div>

        <div className="mb-4">
          <InputText
            label={"Fecha vencimiento"}
            name={"fecha_vencimiento"}
            type={"date"}
            placeholder={"Ingrese descripcion..."}
            register={register}
            errors={errors.descripcion?.message}
          />
        </div>

        <div className="mb-6 text-center">
          <button
            className="w-full mt-3 px-4 py-2 font-bold text-white bg-blue-500 rounded-full hover:bg-blue-700 focus:outline-none focus:shadow-outline"
            type="submit"
          >
            Registrar Vacunas
          </button>
        </div>
        <hr className="mb-6 border-t" />
      </form>
    </>
  );
}

export default ActionModal;
