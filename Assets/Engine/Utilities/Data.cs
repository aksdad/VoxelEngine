using UnityEngine;
public static class Data {

    public static Vector3[] chunkLoadOrder = {   new Vector3( 0, 0,  0), new Vector3(-1, 0,  0), new Vector3( 0, 0, -1), new Vector3( 0, 0,  1), new Vector3( 1, 0,  0),
    new Vector3(-1, 0, -1), new Vector3(-1, 0,  1), new Vector3( 1, 0, -1), new Vector3( 1, 0,  1), new Vector3(-2, 0,  0),
    new Vector3( 0, 0, -2), new Vector3( 0, 0,  2), new Vector3( 2, 0,  0), new Vector3(-2, 0, -1), new Vector3(-2, 0,  1),
    new Vector3(-1, 0, -2), new Vector3(-1, 0,  2), new Vector3( 1, 0, -2), new Vector3( 1, 0,  2), new Vector3( 2, 0, -1),
    new Vector3( 2, 0,  1), new Vector3(-2, 0, -2), new Vector3(-2, 0,  2), new Vector3( 2, 0, -2), new Vector3( 2, 0,  2),
    new Vector3(-3, 0,  0), new Vector3( 0, 0, -3), new Vector3( 0, 0,  3), new Vector3( 3, 0,  0), new Vector3(-3, 0, -1),
    new Vector3(-3, 0,  1), new Vector3(-1, 0, -3), new Vector3(-1, 0,  3), new Vector3( 1, 0, -3), new Vector3( 1, 0,  3),
    new Vector3( 3, 0, -1), new Vector3( 3, 0,  1), new Vector3(-3, 0, -2), new Vector3(-3, 0,  2), new Vector3(-2, 0, -3),
    new Vector3(-2, 0,  3), new Vector3( 2, 0, -3), new Vector3( 2, 0,  3), new Vector3( 3, 0, -2), new Vector3( 3, 0,  2),
    new Vector3(-4, 0,  0), new Vector3( 0, 0, -4), new Vector3( 0, 0,  4), new Vector3( 4, 0,  0), new Vector3(-4, 0, -1),
    new Vector3(-4, 0,  1), new Vector3(-1, 0, -4), new Vector3(-1, 0,  4), new Vector3( 1, 0, -4), new Vector3( 1, 0,  4),
    new Vector3( 4, 0, -1), new Vector3( 4, 0,  1), new Vector3(-3, 0, -3), new Vector3(-3, 0,  3), new Vector3( 3, 0, -3),
    new Vector3( 3, 0,  3), new Vector3(-4, 0, -2), new Vector3(-4, 0,  2), new Vector3(-2, 0, -4), new Vector3(-2, 0,  4),
    new Vector3( 2, 0, -4), new Vector3( 2, 0,  4), new Vector3( 4, 0, -2), new Vector3( 4, 0,  2), new Vector3(-5, 0,  0),
    new Vector3(-4, 0, -3), new Vector3(-4, 0,  3), new Vector3(-3, 0, -4), new Vector3(-3, 0,  4), new Vector3( 0, 0, -5),
    new Vector3( 0, 0,  5), new Vector3( 3, 0, -4), new Vector3( 3, 0,  4), new Vector3( 4, 0, -3), new Vector3( 4, 0,  3),
    new Vector3( 5, 0,  0), new Vector3(-5, 0, -1), new Vector3(-5, 0,  1), new Vector3(-1, 0, -5), new Vector3(-1, 0,  5),
    new Vector3( 1, 0, -5), new Vector3( 1, 0,  5), new Vector3( 5, 0, -1), new Vector3( 5, 0,  1), new Vector3(-5, 0, -2),
    new Vector3(-5, 0,  2), new Vector3(-2, 0, -5), new Vector3(-2, 0,  5), new Vector3( 2, 0, -5), new Vector3( 2, 0,  5),
    new Vector3( 5, 0, -2), new Vector3( 5, 0,  2), new Vector3(-4, 0, -4), new Vector3(-4, 0,  4), new Vector3( 4, 0, -4),
    new Vector3( 4, 0,  4), new Vector3(-5, 0, -3), new Vector3(-5, 0,  3), new Vector3(-3, 0, -5), new Vector3(-3, 0,  5),
    new Vector3( 3, 0, -5), new Vector3( 3, 0,  5), new Vector3( 5, 0, -3), new Vector3( 5, 0,  3), new Vector3(-6, 0,  0),
    new Vector3( 0, 0, -6), new Vector3( 0, 0,  6), new Vector3( 6, 0,  0), new Vector3(-6, 0, -1), new Vector3(-6, 0,  1),
    new Vector3(-1, 0, -6), new Vector3(-1, 0,  6), new Vector3( 1, 0, -6), new Vector3( 1, 0,  6), new Vector3( 6, 0, -1),
    new Vector3( 6, 0,  1), new Vector3(-6, 0, -2), new Vector3(-6, 0,  2), new Vector3(-2, 0, -6), new Vector3(-2, 0,  6),
    new Vector3( 2, 0, -6), new Vector3( 2, 0,  6), new Vector3( 6, 0, -2), new Vector3( 6, 0,  2), new Vector3(-5, 0, -4),
    new Vector3(-5, 0,  4), new Vector3(-4, 0, -5), new Vector3(-4, 0,  5), new Vector3( 4, 0, -5), new Vector3( 4, 0,  5),
    new Vector3( 5, 0, -4), new Vector3( 5, 0,  4), new Vector3(-6, 0, -3), new Vector3(-6, 0,  3), new Vector3(-3, 0, -6),
    new Vector3(-3, 0,  6), new Vector3( 3, 0, -6), new Vector3( 3, 0,  6), new Vector3( 6, 0, -3), new Vector3( 6, 0,  3),
    new Vector3(-7, 0,  0), new Vector3( 0, 0, -7), new Vector3( 0, 0,  7), new Vector3( 7, 0,  0), new Vector3(-7, 0, -1),
    new Vector3(-7, 0,  1), new Vector3(-5, 0, -5), new Vector3(-5, 0,  5), new Vector3(-1, 0, -7), new Vector3(-1, 0,  7),
    new Vector3( 1, 0, -7), new Vector3( 1, 0,  7), new Vector3( 5, 0, -5), new Vector3( 5, 0,  5), new Vector3( 7, 0, -1),
    new Vector3( 7, 0,  1), new Vector3(-6, 0, -4), new Vector3(-6, 0,  4), new Vector3(-4, 0, -6), new Vector3(-4, 0,  6),
    new Vector3( 4, 0, -6), new Vector3( 4, 0,  6), new Vector3( 6, 0, -4), new Vector3( 6, 0,  4), new Vector3(-7, 0, -2),
    new Vector3(-7, 0,  2), new Vector3(-2, 0, -7), new Vector3(-2, 0,  7), new Vector3( 2, 0, -7), new Vector3( 2, 0,  7),
    new Vector3( 7, 0, -2), new Vector3( 7, 0,  2), new Vector3(-7, 0, -3), new Vector3(-7, 0,  3), new Vector3(-3, 0, -7),
    new Vector3(-3, 0,  7), new Vector3( 3, 0, -7), new Vector3( 3, 0,  7), new Vector3( 7, 0, -3), new Vector3( 7, 0,  3),
    new Vector3(-6, 0, -5), new Vector3(-6, 0,  5), new Vector3(-5, 0, -6), new Vector3(-5, 0,  6), new Vector3( 5, 0, -6),
    new Vector3( 5, 0,  6), new Vector3( 6, 0, -5), new Vector3( 6, 0,  5) };
}
